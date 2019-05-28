const GetDocumentRequest = async (component) =>
	// eslint-disable-next-line no-undef
	await fetch('https://localhost:5001/api/Document')
		.then(res => res.json())
		.then(json => {
			component.setState({
				isLoaded: true,
				items: json
			});
		});

export default GetDocumentRequest;