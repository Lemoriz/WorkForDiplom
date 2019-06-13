import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table-plus';
import GetSendForApprovalDoc from '../Requests/GetSendForApprovalDoc';
import GetDocumentTypeRequest from '../Requests/GetDocumentTypeRequest';
import SendForApprovalRequest from '../Requests/SendForApprovalRequest';
import PropTypes from 'prop-types';

class SendDocumentForApproval extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: [],
			isLoaded: false,
			selectedElement: {}
		};
    
		this.insertBtn = this.insertBtn.bind(this);
	}
  
	insertBtn() {

		return (
			<button className = "btn btn-primary" type="submit" onClick={ () => {
				if(!this.state.selectedElement.documentId)
				{
					alert('Выберете документ для отправки');
					return;
				}
				SendForApprovalRequest(this.state.selectedElement.documentId, this.props.userInfo.employeeId)
				this.forceUpdate();
			} } >Отправить документ на согласование</button>
		);
	}

	componentDidMount() {
		// eslint-disable-next-line no-undef
		return Promise.all([ GetSendForApprovalDoc(false), GetDocumentTypeRequest() ])
			.then(results => {
				const documents = results[ 0 ];
				const documentTypes = results[ 1 ];
				debugger;

				const resilt = documents.map(document => {
					document.documentTypeId = documentTypes.find(documentType => documentType.documentTypeId === document.documentTypeId).name;
					return document;
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
			<div className="container addDoc">
				<BootstrapTable
					data={ items }
					insertRow={ true }
					search={ true }
					selectRow={ { mode: 'radio', onSelect: (row) => this.setState({ selectedElement: row }) } }
					options={ { insertBtn: this.insertBtn } }
				>
					<TableHeaderColumn width='5%' dataField="documentId" isKey dataSort>ID</TableHeaderColumn>
					<TableHeaderColumn dataField="name"  dataSort>Имя документа</TableHeaderColumn>
					<TableHeaderColumn dataField="shortDiscription"  dataSort>Краткое описание</TableHeaderColumn>
					<TableHeaderColumn dataField="creationDate"  dataSort>Дата создания</TableHeaderColumn>
					<TableHeaderColumn dataField="path"  dataSort>Путь к файлу</TableHeaderColumn>
					<TableHeaderColumn width='10%' dataField="size"  dataSort>Размер</TableHeaderColumn>
					<TableHeaderColumn width='15%' dataField="documentTypeId"  dataSort>Тип документа</TableHeaderColumn>
				</BootstrapTable>
			</div>
		);
	}
}

SendDocumentForApproval.propTypes = {
	userInfo: PropTypes.object
};

SendDocumentForApproval.defaultProps = {
	userInfo: {}
};

export default SendDocumentForApproval;