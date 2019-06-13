import serverName from '../serverName';

const ActionStatusRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/ActionStatus`)
		.then(res => res.json());

export default ActionStatusRequest;