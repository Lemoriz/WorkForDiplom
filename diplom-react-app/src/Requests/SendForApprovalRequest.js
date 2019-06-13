import serverName from '../serverName';

const SendForApprovalRequest = async (documentId, employeeId) =>{
	// eslint-disable-next-line no-undef
	return await fetch(`${ serverName }/api/SendDocumentForApproval`, {
		method: 'POST',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json',
		},
		body: JSON.stringify({
			documentId,
			employeeId,
			ActionId: 1
		})
	}).then(res => res.status !== 200 ? alert('Ошибка! Документ не был отправлен на согласование') : alert('Документ был успешно отправлен на согласование'));
}

export default SendForApprovalRequest;