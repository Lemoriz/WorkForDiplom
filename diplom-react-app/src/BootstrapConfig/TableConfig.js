import React from 'react';
import { InsertButton, DeleteButton } from 'react-bootstrap-table-plus';

const handleInsertButtonClick = (onClick) => {
	// Custom your onClick event here,
	// it's not necessary to implement this function if you have no any process before onClick
	console.log(onClick);
}

const handleDeleteButtonClick = (onClick) => {
	// Custom your onClick event here,
	// it's not necessary to implement this function if you have no any process before onClick
	if(10 > 5){
		alert('Недостаточно прав!');

		return;
	}
	
	onClick();
}

const createCustomInsertButton = (onClick) => {
	debugger;
	return (
		<InsertButton
			btnText='Редактировать'
			onClick={ () => handleInsertButtonClick(onClick) }/>
	);
}

const createCustomDeleteButton = (onClick) => {
	debugger;
	return (
		<DeleteButton
			btnText='Удалить'
			onClick={ () => handleDeleteButtonClick(onClick) }/>
	);
}

function onSelect(row) {
	debugger;
	// let newRowStr = '';

	// for (const prop in row) {
	// 	newRowStr += prop + ': ' + row[ prop ] + ' \n';
	// }
	// alert('The new row is:\n ' + newRowStr);
}

function afterSearch(searchText, result) {
	// console.log('Your search text is ' + searchText);
	// console.log('Result is:');
	// for (let i = 0; i < result.length; i++) {
	// 	console.log('Fruit: ' + result[ i ].id + ', ' + result[ i ].name + ', ' + result[ i ].price);
	// }
}

const Options = {
	insertBtn: createCustomInsertButton,
	deleteBtn: createCustomDeleteButton,
	afterSearch: afterSearch,
//	afterInsertRow: onAfterInsertRow,
	onSelect : onSelect 
	// exportCSVText: 'my_export',
	// insertText: 'my_insert',
	// saveText: 'my_save',
	// closeText: 'my_close'
};

export { Options };