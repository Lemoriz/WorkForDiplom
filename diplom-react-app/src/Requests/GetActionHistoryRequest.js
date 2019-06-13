import serverName from '../serverName';

const GetActionHistoryRequest = async (component) =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/ActionHistory`)
		.then(res => res.json())

export default GetActionHistoryRequest;