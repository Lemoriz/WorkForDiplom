import React from 'react';
import './index.css'
import PropTypes from 'prop-types';
import AddFileRequest from '../Requests/AddFileRequest';

class AddDocument extends React.Component {
	constructor(props) {
		super(props);

		this.state = { 
			files: {},
			name: '',
			shortDiscription: ''      
		};
	}

  fileChanged = (e) => {
  	this.setState({ file : e.target.files[ 0 ] });
  }	

  handleChange  = (e) => {
  	this.setState({ [ e.target.name ]: e.target.value });
  }

	handleSubmit = () => {
		// eslint-disable-next-line no-undef
		const formData = new FormData();
    
		if(!this.state.name && !this.state.shortDiscription && !this.state.file){
			// eslint-disable-next-line no-undef
			alert('Заполните все поля!');
			return;
		}
    
		formData.append('File ', this.state.file);
		formData.append('Name', this.state.name );
		formData.append('EmployeeID', this.props.userInfo.employeeId );
		formData.append('ShortDescription', this.state.shortDiscription);
		formData.append('EncryptHash', '5as6d4as68d46sad');
		formData.append('PublicKey', '468a4sd6as4d684');
      
		AddFileRequest(formData);
	}

	render() {
		return (
			<div className = 'addDoc'>
				<input type="text" className="form-control" name="name" placeholder="Название документа" onChange = { this.handleChange  }/>              
				<input type="text" className="form-control" name="shortDiscription" placeholder="Краткое описание документа" onChange = { this.handleChange  }/>

				<input className="file" name="qwewqe" type="file" onChange={ this.fileChanged } accept=".txt,.docx,.pdf,.xls" />
				<button className="submitButton" type="submit" onClick={ this.handleSubmit }>Загрузить документ</button>
			</div>
		)
	}
}

AddDocument.propTypes = {
	userInfo: PropTypes.object
};

AddDocument.defaultProps = {
	userInfo: {}
};

export default AddDocument;