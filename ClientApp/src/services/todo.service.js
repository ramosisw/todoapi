import { config } from '../config'
import { handleResponse } from '../helpers/handleResponse'

export const todoService = {
    get
};

const TODO_PATH = '/todo';

/**
 * list all tasks
 */
function get() {
    const requestOptions = {
        method: 'GET'
    };
    return fetch(`${config.apiUrl}${TODO_PATH}`, requestOptions).then(handleResponse);
}