import serverName from '../serverName';

const GetDocumentTypeRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch(`${ serverName }/api/DocumentType`)
		.then(res => res.json());

export default GetDocumentTypeRequest;