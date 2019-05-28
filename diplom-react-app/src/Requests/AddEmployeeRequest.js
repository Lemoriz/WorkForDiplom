const AddEmployeeRequest = async (e) => {
	// eslint-disable-next-line no-undef
	return await fetch('https://localhost:5001/api/Employee', {
		method: 'POST',
		headers: {
			'Accept': 'application/json',
			'Content-Type': 'application/json',
		},
		body: JSON.stringify({
			name: e.employeeNameRegistration,
			surname: e.employeeFNameRegistration,
			middleName: '',
			telephoneNumber: '',
			email: e.emailRegistration,
			positionId: e.positionRegistration,
			subdivisionId: e.subdivisionRegistration,
			companyId: '1',
			password: e.passwordRegistrationOne
		})
	})
}
export default AddEmployeeRequest;