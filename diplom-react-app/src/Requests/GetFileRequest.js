import serverName from '../serverName';

const GetFileRequest = (fileId) =>
	// eslint-disable-next-line no-undef
	window.open(`${ serverName }/api/DownloadFile/${ fileId }`, '_self');

export default GetFileRequest;