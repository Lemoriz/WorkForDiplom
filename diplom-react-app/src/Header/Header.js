import React, { Component } from 'react';
import './index.css'
import PropTypes from 'prop-types';
import MenuItem from '../Forms/MenuItem';
import UserMenu from './UserMenu';

class Header extends Component {
	constructor() {
		super();
		
		this.state = { 
			open: false,
			isMouseInside: false,
			menuItemElement: null,
			userInfo: {},
			userLogin: true
		};
	}

	componentWillMount(){
		this.setState({ userInfo: this.props.userInfo });
	}

	updateData = (value) => {
		this.setState({ menuItemElement: value })
	 }

	userMenuUpdateData = (value) => {
		this.props.headerUpdateData({ userLogin: value.userLogin })
	}
	
	toggle() {
		this.setState({
			open: !this.state.open
		});
	}
	
	render() {
		return (
			<div>
				<div>
					<header>
						<nav className="navbar navbar-light bg-light">
							<div>
								<h5 className="text-center">Меню</h5>
								<button 
									className="navbar-toggler" 
									type="button" 
									onClick={ this.toggle.bind(this) } 
									data-toggle="collapse" 
									data-target="#navbarText" 
									aria-controls="navbarText" 
									aria-expanded="false" 
									aria-label="Toggle navigation"
								>
									<span className="navbar-toggler-icon"></span>
								</button>
							</div>
							<div id="navbarText">
								<h3 className="text-center">DocFlow</h3>
							</div>
							<UserMenu userInfo={ this.state.userInfo } userMenuUpdateData={ this.userMenuUpdateData }/>
						</nav>
					</header>
				</div>
				{
					this.state.open 
						? <div className="list-group">
							<MenuItem name = 'Добавить документ' clickID = 'addDocument' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
							<MenuItem name = 'Редактировать документ' clickID = 'editDocument' updateData={ this.updateData }/>
							<MenuItem name = 'Просмотреть список документов' clickID = 'showListDocument' updateData={ this.updateData }/>
							<MenuItem name = 'Отправить документ на согласование' clickID = 'showListDocument' updateData={ this.updateData }/>
							<MenuItem name = 'Согласовать документ' clickID = 'showListDocument' updateData={ this.updateData }/>
							<MenuItem name = 'Результаты мониторинга' clickID = 'showListDocument' updateData={ this.updateData }/>
						</div>
						: null
				}
				{ this.state.menuItemElement }
			</div>
		);
	}
};

Header.propTypes = {
	userInfo: PropTypes.object,
	headerUpdateData: PropTypes.func
};

Header.defaultProps = {
	userInfo: {}
};

export default Header;