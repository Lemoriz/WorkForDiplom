import serverName from '../serverName';

/* eslint-disable no-undef */
import axios from 'axios';

const AddFileRequest = async (formData) => axios.post(`${ serverName }/api/UploadFile`, formData, {})
	.then(()=> alert('Файл был успешно добавлен!'))
	.catch(() => alert('Внимание! Файл не был добавлен!'))

export default AddFileRequest;