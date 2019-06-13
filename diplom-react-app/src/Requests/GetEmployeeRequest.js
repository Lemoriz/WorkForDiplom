import serverName from '../serverName';

const GetEmployeeRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/Employee`)
		.then(res => res.json());

export default GetEmployeeRequest;