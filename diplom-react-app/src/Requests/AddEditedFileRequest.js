import serverName from '../serverName';

/* eslint-disable no-undef */
import axios from 'axios';

const AddEditedFileRequest = async (formData) => axios.post(`${ serverName }/api/ReplaceUploadedFile`, formData, {})
	.then(()=> alert('Файл был успешно изменен!'))
	.catch(() => alert('Внимание! Файл не был изменен!'))

export default AddEditedFileRequest;