import serverName from '../serverName';

const ApprovalRequest = async (documentId, employeeId) =>{
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
			ActionId: 2
		})
	}).then(res => res.status !== 200 ? alert('Ошибка! Документ не был согласован') : alert('Документ был успешно согласован'));
}

export default ApprovalRequest;