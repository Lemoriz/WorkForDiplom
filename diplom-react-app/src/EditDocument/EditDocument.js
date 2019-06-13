import React, { Component } from 'react';
import { BootstrapTable, TableHeaderColumn } from 'react-bootstrap-table-plus';
import GetDocumentRequest from '../Requests/GetDocumentRequest';
import GetDocumentTypeRequest from '../Requests/GetDocumentTypeRequest';
import GetFileRequest from '../Requests/GetFileRequest';
import AddEditedFileRequest from '../Requests/AddEditedFileRequest';
import PropTypes from 'prop-types';
import './bootstrapTable.css';

class EditDocument extends Component {
	constructor(props) {
		super(props);

		this.state = {
			items: [],
			isLoaded: false,
			selectedElement: {},
			files: {}
		};
		this.insertBtn = this.insertBtn.bind(this);
		this.deleteBtn = this.deleteBtn.bind(this);
	}
  
	insertBtn() {

		return (
			<button className = "btn btn-primary" type="submit" onClick={ () => {
				if(!this.state.selectedElement.documentId)
				{
					alert('Выберете документ для скачивания');
					return;
				}
				GetFileRequest(this.state.selectedElement.documentId) 
			} } >Скачать файл</button>
		);
	}

	deleteBtn() {
		return (
			<>
				<input type="file" accept=".txt,.docx,.pdf,.xls" onChange={ (e) => this.setState({ file : e.target.files[ 0 ] }) }/>
				<button className="btn btn-success" type="file" accept=".txt,.docx,.pdf,.xls" onClick={ () => {
					// eslint-disable-next-line no-undef
					const formData = new FormData();

					if(!this.state.file){
						alert('Загрузите файл');
						return;
					}
					if(Object.keys(this.state.selectedElement).length === 0){
						alert('Выберете документ для изменения');
						return;
					}
					debugger;

					formData.append('File ', this.state.file);
					formData.append('Name', this.state.selectedElement.name );
					formData.append('EmployeeID', this.props.userInfo.employeeId );
					formData.append('ShortDescription', this.state.selectedElement.shortDiscription);
					formData.append('DocumentID', this.state.selectedElement.documentId);
					formData.append('Path', this.state.selectedElement.path);
					formData.append('EncryptHash', '5as6d4as68d46sad');
					formData.append('PublicKey', '468a4sd6as4d684');
      
					AddEditedFileRequest(formData);
				 } }>Загрузить измененный файл</button>
			</>);
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
					insertRow={ true }
					deleteRow={ true }
					search={ true }
					selectRow={ { mode: 'radio', onSelect: (row) => this.setState({ selectedElement: row }) } }
					options={ { insertBtn: this.insertBtn, deleteBtn: this.deleteBtn } }
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

EditDocument.propTypes = {
	userInfo: PropTypes.object
};

EditDocument.defaultProps = {
	userInfo: {}
};

export default EditDocument;