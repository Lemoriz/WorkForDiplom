import serverName from '../serverName';

const GetUserAuthorizRequest = async (userName, password) =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/authorizInfo/${ userName }/${ password }`)
		.then(res => res.status !== 200 ? null : res.json())

export default GetUserAuthorizRequest;