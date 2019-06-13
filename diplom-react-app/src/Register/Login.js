import React, { Component } from 'react';
import PropTypes from 'prop-types';
import Registration from './Registration';
import GetUserAuthorizRequest from '../Requests/GetUserAuthorizRequest';

class Login extends Component {
	constructor() {
		super();

		this.state = { 
			clickedButton: false,
			registrationMode: false,			
			inputFormValues: {
				'emailLogin': '',
				'passwordLogin': ''
			},
		};

		this.enterClick = this.enterClick.bind(this);
		this.registrationClick = this.registrationClick.bind(this);
	}
	//В первый аргумент функции прилетает что-то непонятное.
	enterClick(a, emailLogin = this.state.inputFormValues.emailLogin, passwordLogin = this.state.inputFormValues.passwordLogin) {
		//this.props.updateData({ logIn: true });
		GetUserAuthorizRequest(emailLogin, passwordLogin)
			.then(result => {
				if(!result){
					// eslint-disable-next-line no-undef
					alert('Неверный логин или пароль');
				}else{
					this.props.updateData({ logIn: true, userInfo: result });
				}
			});
	}

	registrationClick() {
		this.setState({ registrationMode: true });
	}

	updateData = (value) => {
		this.setState({ registrationMode: value.areadyRegistrationClick });
		this.props.updateData(value.registrationClick);

		if(value.loginInformation){
			this.enterClick('', value.loginInformation.login, value.loginInformation.password);
		}
	}

	inputFormValues = (value) => {
		const inputFormsObj= this.state.inputFormValues;

		Object.keys(inputFormsObj).forEach(key => {
			if (key === value.target.id){
				inputFormsObj[ key ] = value.target.value;
			}
		})
		
		this.setState({ inputFormValues: inputFormsObj })
	}

	render() {
		return(
			<div className = "container">
				{
					this.state.registrationMode 
						? < Registration updateData={ this.updateData }/> 
						: <form className="text-center border-light p-5">
							<p className="h4 mb-4">Авторизация</p>
							<input type="email" id="emailLogin" className="form-control mb-4" autoComplete="on" placeholder="E-mail" onChange = { this.inputFormValues }/>
							<input type="password" id="passwordLogin" className="form-control mb-4" autoComplete="on" placeholder="Пароль" onChange = { this.inputFormValues }/>
							<div className="d-flex justify-content-around">
								<div>
									<div className="custom-control custom-checkbox">
										<input type="checkbox" className="custom-control-input" id="defaultLoginFormRemember"/>
										<label className="custom-control-label" htmlFor="defaultLoginFormRemember">Запомнить меня</label>
									</div>
								</div>
							</div>
							<button className="btn btn-info btn-block my-4" type="button" onClick={ this.enterClick } >Вход</button>
							<p>Не зарегистрированы?
								<button type="button" className="btn btn-link" onClick={ this.registrationClick } >Регистрация</button>
							</p>
						</form>
				}
			</div>
		);
	}
}

Login.propTypes = {
	clickedButton: PropTypes.bool,
	updateData : PropTypes.func,
	registrationMode : PropTypes.bool
};

export default Login