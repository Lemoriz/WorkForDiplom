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
			<div className="d-flex" id="wrapper">
				<div className="bg-light border-right" id="sidebar-wrapper">
					{
						this.state.open 
							?<div>      
								<div className="sidebar-heading">Работа с документом </div> 
								<div className="list-group list-group-flush">
									<MenuItem name = 'Добавить документ' clickID = 'addDocument' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
									<MenuItem name = 'Редактировать документ' clickID = 'editDocument' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
									<MenuItem name = 'Просмотреть список документов' clickID = 'viewAllDocuments' updateData={ this.updateData }/>
									<MenuItem name = 'Отправить документ на согласование' clickID = 'sendForApproval' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
									<MenuItem name = 'Согласовать документ' clickID = 'approval' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
									<MenuItem name = 'Результаты мониторинга' clickID = 'monitoringResults' updateData={ this.updateData } userInfo={ this.state.userInfo }/>
								</div>			
							</div> 			
							: null
					}
				</div>
				<div id="page-content-wrapper">
					<nav className="navbar navbar-light bg-light">
						<button 
							className="navbar-toggler" 
							type="button" 
							onClick={ this.toggle.bind(this) } 
						>
							<span className="navbar-toggler-icon"></span>
						</button>
						<li className="nav navbar-nav navbar-center" text="align:center">
							<h3 className="text-center">DocFlow</h3>
						</li>
						<UserMenu userInfo={ this.state.userInfo } userMenuUpdateData={ this.userMenuUpdateData }/>
					</nav>
					<div className="wr">
						{ this.state.menuItemElement }
					</div>
				</div>
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