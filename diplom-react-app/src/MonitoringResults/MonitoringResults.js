import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table-plus';
import { Options } from '../BootstrapConfig/TableConfig';
import GetDocumentRequest from '../Requests/GetDocumentRequest';
import GetActionHistoryRequest from '../Requests/GetActionHistoryRequest';
import GetEmployeeRequest from '../Requests/GetEmployeeRequest';
import ActionStatusRequest from '../Requests/ActionStatusRequest';
import GetActionRequest from '../Requests/GetActionRequest';

class MonitoringResults extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: [],
			isLoaded: false
		};
	}

	componentDidMount() {

		// eslint-disable-next-line no-undef
		return Promise.all([ GetActionHistoryRequest(), GetActionRequest(), GetEmployeeRequest(), GetDocumentRequest(), ActionStatusRequest() ])
			.then(results => {
				const actionHistorys = results[ 0 ];
				const actions = results[ 1 ];
				const employees = results[ 2 ];
				const documents = results[ 3 ];
				const actionStatuses = results[ 4 ];
				// const documentTypes = results[ 1 ];

				const resilt = actionHistorys.map(actionHistory => {
					actionHistory.employeeId = employees.find(employee => employee.employeeId === actionHistory.employeeId).name;
					actionHistory.documentId = documents.find(document => document.documentId === actionHistory.documentId).name;
					actionHistory.actionStatusId = actionStatuses.find(actionStatus => actionStatus.actionStatusId === actionHistory.actionStatusId).name;
					actionHistory.actionId = actions.find(action => action.actionId === actionHistory.actionId).name;
					return actionHistory;
				});

				this.setState({
					isLoaded: true,
					items: resilt
				});
			})
	}

	render() {
		const { isLoaded, items } = this.state;

		if (!isLoaded) {
			return <div>Loading...</div>;
		}

		return (
			this.props.userInfo.employeeId === 12 ?
				<div className="container addDoc">        
					<h2 style={ { color: 'green' } }>Аномалий не обнаружено</h2>
					<BootstrapTable
						data={ items }
						pagination
						hover
						condensed
						deleteRow={ false }
						insertRow={ false }
						search={ true }
						options={ Options }
					>
						<TableHeaderColumn width='5%' dataField="actionHistoryId" isKey dataSort>ID</TableHeaderColumn>
						<TableHeaderColumn width='25%'dataField="date"  dataSort>Дата</TableHeaderColumn>
						<TableHeaderColumn width='25%'dataField="actionStatusId"  dataSort>Статус действия</TableHeaderColumn>
						<TableHeaderColumn width='10%'dataField="documentId"  dataSort>Документ</TableHeaderColumn>
						<TableHeaderColumn width='10%' dataField="employeeId"  dataSort>Работник</TableHeaderColumn>
						<TableHeaderColumn  dataField="actionId"  dataSort>Действие</TableHeaderColumn>
					</BootstrapTable>
				</div>
			// eslint-disable-next-line no-undef
				: <>{alert('Вкладка доступна только сотруднику отдела мониторинга')}</>
		);
	}
}

export default MonitoringResults;