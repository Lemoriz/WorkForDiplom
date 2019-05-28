import React, { Component } from 'react';
import PropTypes from 'prop-types';
import InputForm from './InputForm';
import SelectionForm from './SelectionForm';
import AddEmployeeRequest from '../Requests/AddEmployeeRequest';

class Registration extends Component {
	constructor(props) {
		super(props);

		this.state = {
			validInputForms: {
				'employeeNameRegistration': false,
				'employeeFNameRegistration': false,
				'emailRegistration': false,
				'passwordRegistrationOne': false,
				'passwordRegistrationTwo': false,
				'positionRegistration': false,
				'subdivisionRegistration': false
			},
			inputFormValues: {
				'employeeNameRegistration': '',
				'employeeFNameRegistration': '',
				'emailRegistration': '',
				'passwordRegistrationOne': '',
				'passwordRegistrationTwo': '',
				'positionRegistration': '',
				'subdivisionRegistration': ''
			},
			allFormsValid: false
		};
		this.registrationClick = this.registrationClick.bind(this);
		this.areadyRegistrationClick = this.areadyRegistrationClick.bind(this);
		this.regClick = this.regClick.bind(this);
	}
  
	registrationClick() {
		this.props.updateData({ 
			registrationClick: true, 
			areadyRegistrationClick: true, 
			loginInformation: { 
				login: this.state.inputFormValues.emailRegistration, 
				password: this.state.inputFormValues.passwordRegistrationOne 
			} 
		});
	}

	areadyRegistrationClick() {
		this.props.updateData({ registrationClick: false, areadyRegistrationClick: false });
	}

	inputFormValues = (value) => {
		const inputFormsObj= this.state.inputFormValues;

		Object.keys(inputFormsObj).forEach(key => {
			if ((value.id === 'positionRegistration' && key === value.id) || (value.id === 'subdivisionRegistration' && key === value.id)){
				inputFormsObj[ key ] = value.resultId;
			} else if (key === value.id) {
				inputFormsObj[ key ] = value.result;
			}
		})
		this.setState({ inputFormValues: inputFormsObj })
	}

	validInputForm = (value) => {
		
		const inputFormsObj= this.state.validInputForms;
		let validFlag = true;

		Object.keys(inputFormsObj).forEach(key => {
			if (key === value.id){
				inputFormsObj[ key ] = value.result;
			}
			if(!inputFormsObj[ key ]){
				validFlag = false;
			}
		})

		this.setState({ validInputForms: inputFormsObj, allFormsValid: validFlag })
	}

	/* eslint-disable no-undef */
	regClick() {
		if(this.state.allFormsValid){ 
			AddEmployeeRequest(this.state.inputFormValues).then(result => {
				if(result.status === 200){
					alert('Успешная регистрация!')
					this.registrationClick()
				}				
			}).catch(() => alert('Внимание! Произошла ошибка!'))
		}else {
			alert('Все поля должны быть верно заполнены')
		}
	}

	render() {
		return(
			<form className="text-center border border-light p-5">   
				<p className="h4 mb-4">Регистрация</p>
				<InputForm 
					type="text"
					id="employeeNameRegistration" 
					placeholder="Имя сотрудника" 
					idHelp="employeeNameHelp"
					textHelp="Поле не должно быть пустым"
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
				/>
				<InputForm 
					type="text"
					id="employeeFNameRegistration" 
					placeholder="Фамилия сотрудника"
					idHelp="employeeFNameHelp"
					textHelp="Поле не должно быть пустым"
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
				/>
				<SelectionForm 
					id="positionRegistration" 
					placeholder="Выберете должность" 
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
					textHelp="Обязательно выберете должность"
				/>
				<SelectionForm 
					id="subdivisionRegistration" 
					placeholder="Выберете подразделение" 
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
					textHelp="Обязательно выберете подразделение"
				/>
				<InputForm 
					type="email"
					id="emailRegistration" 
					placeholder="E-mail" 
					idHelp="emailHelp"
					textHelp="Некорректный Email"
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
				/>
				<InputForm 
					type="password"
					id="passwordRegistrationOne" 
					placeholder="Пароль" 
					idHelp="passwordHelpOne"
					textHelp="Пароль должен быть длиннее 6 символов и иметь: заглавную и строчную буквы, цифру, специальный символ"
					inputFormValues={ this.inputFormValues }
					validInputForm={ this.validInputForm }
				/>
				<InputForm 
					type="password"
					id="passwordRegistrationTwo" 
					placeholder="Подтвердите пароль" 
					idHelp="passwordHelpTwo"
					textHelp="Пароли должны совпадать"
					inputFormValues={ this.inputFormValues }
					passwordOne={ this.state.inputFormValues.passwordRegistrationOne }
					validInputForm={ this.validInputForm }
				/>
				<div className="d-flex justify-content-around"/>
				<button className="btn btn-info btn-block my-4" type="button" onClick={ this.regClick }>Зарегистрироваться</button>
				<p>Уже зарегестрированы?
					<button type="button" className="btn btn-link" onClick={ this.areadyRegistrationClick }>Жми</button>
				</p>
			</form>
		);
	}
}

Registration.propTypes = {
	updateData: PropTypes.func,
	validInputForm: PropTypes.bool
};

export default Registration