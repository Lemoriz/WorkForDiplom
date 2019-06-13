import serverName from '../serverName';

const GetActionRequest = async (component) =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/Action`)
		.then(res => res.json())

export default GetActionRequest;