import serverName from '../serverName';

const GetDocumentRequest = async (component) =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/Document`)
		.then(res => res.json())

export default GetDocumentRequest;