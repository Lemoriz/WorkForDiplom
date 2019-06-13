import serverName from '../serverName';

const GetPositionsRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/Position`)
		.then(res => res.json());

export default GetPositionsRequest;