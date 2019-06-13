import serverName from '../serverName';

const GetSendForApprovalDoc = async (wantToAppove = true) =>
// eslint-disable-next-line no-undef
{
	const resultAction = wantToAppove ? 'wantToApprove' : 'noWantToApprove';
	return await fetch(`${ serverName }/api/Document/${ resultAction }`)
		.then(res => res.json());
}

export default GetSendForApprovalDoc;