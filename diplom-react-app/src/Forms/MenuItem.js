import React, { Component } from 'react';
import PropTypes from 'prop-types';
import AddDocument from '../Document/AddDocument';
import GetDocument from '../Document/GetDocument';
import EditDocument from '../EditDocument/EditDocument';
import SendDocumentForApproval from '../SendDocumentForApproval/SendDocumentForApproval';
import ApprovalDocument from '../ApprovalDocument/ApprovalDocument';
import MonitoringResults from '../MonitoringResults/MonitoringResults';

class MenuItem extends Component {
	constructor() {
		super();

		this.state = { 
			isToggleOn: true
		};
		this.menuItemClick = this.menuItemClick.bind(this);
	}
	
	menuItemClick() {
		if(this.state.isToggleOn){
			if(this.props.clickID === 'addDocument'){
				this.props.updateData(<AddDocument userInfo={ this.props.userInfo }/>);
			}
			if(this.props.clickID === 'editDocument'){
				this.props.updateData(<EditDocument userInfo={ this.props.userInfo }/>);
			}
			if(this.props.clickID === 'viewAllDocuments'){
				this.props.updateData(<GetDocument/>);
			}
			if(this.props.clickID === 'sendForApproval'){
				this.props.updateData(<SendDocumentForApproval userInfo={ this.props.userInfo }/>);
			}
			if(this.props.clickID === 'approval'){
				this.props.updateData(<ApprovalDocument userInfo={ this.props.userInfo }/>);
			}
			if(this.props.clickID === 'monitoringResults'){
				this.props.updateData(<MonitoringResults userInfo={ this.props.userInfo }/>);
			}
		}else{
			this.props.updateData(null);
		}

		this.setState(state => ({
		  isToggleOn: !state.isToggleOn
		}));
	}
	
	render() {
		return (
			<div>
				<button 
					type="button"
					className={ this.state.isMouseInside ? 'list-group-item list-group-item-action active' : 'list-group-item list-group-item-action' }
					onClick={ this.menuItemClick }
				>
					{ this.props.name }
				</button>
			</div>
		);
	}
};

MenuItem.propTypes = {
	clickID: PropTypes.string,
	name: PropTypes.string,
	updateData : PropTypes.func,
	userInfo: PropTypes.object,
};

MenuItem.defaultProps = {
	userInfo: {}
};

export default MenuItem;