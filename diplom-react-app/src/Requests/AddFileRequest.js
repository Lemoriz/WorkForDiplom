/* eslint-disable no-undef */
import axios from 'axios';

const AddFileRequest = async (formData) => axios.post('https://localhost:5001/api/UploadFile', formData, {})
	.then((result)=> alert('Файл был успешно добавлен!'))
	.catch((result) => alert('Внимание! Файл не был добавлен!'))

export default AddFileRequest;