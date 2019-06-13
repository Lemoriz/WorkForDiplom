import serverName from '../serverName';

const GetSubdivisionsRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/Subdivision`)
		.then(res => res.json());
		
export default GetSubdivisionsRequest;