const GetPositionsRequest = async () =>
	// eslint-disable-next-line no-undef
	await fetch('https://localhost:5001/api/Position')
		.then(res => res.json());

export default GetPositionsRequest;