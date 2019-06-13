import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table-plus';
import { Options } from '../BootstrapConfig/TableConfig';
import GetDocumentRequest from '../Requests/GetDocumentRequest';
import GetDocumentTypeRequest from '../Requests/GetDocumentTypeRequest';
import './index.css';
import './bootstrapTable.css';

class GetDocument extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: [],
			isLoaded: false
		};
	}

	componentDidMount() {

		// eslint-disable-next-line no-undef
		return Promise.all([ GetDocumentRequest(), GetDocumentTypeRequest() ])
			.then(results => {
				const documents = results[ 0 ];
				const documentTypes = results[ 1 ];

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
					pagination
					hover
					condensed
					deleteRow={ false }
					insertRow={ false }
					search={ true }
					options={ Options }
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

export default GetDocument;