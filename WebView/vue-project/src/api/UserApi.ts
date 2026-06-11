import axios from 'axios'
import type { UserResponse } from '@/models/UserResponse'

const BASR_URL = 'http://localhost:5231/api/';
const USER_URL = `${BASR_URL}users/`;

export async function getUserById(id: string): Promise<UserResponse> {

    try{

        const response = await axios.get(`${USER_URL}${id}`)

        return response.data

    } catch (error) {

        return parseError(error)
    }
}

export async function getAllUsers(): Promise<UserResponse> {

    try {

        const response = await axios.get(`${USER_URL}all`)

        return response.data

    } catch (error) {
        
        return parseError(error)
    }
}

export async function addUser(
    account: string, 
    name: string, 
    age: number|null,
    salary: number|null,
    birthday: string): Promise<UserResponse> {

    console.log(`account = ${account} name = ${name} age = ${age} salary = ${salary} birthday = ${birthday}`)

    const request: any = {
        account: account,
        name: name,
        enabled: true
    }

    if (age != null) {
        request.age = age
    }

    if (salary != null) {
        request.salary = salary
    }

    if (birthday != null && birthday.length > 0) {
        request.birthday = birthday
    }

    try {
        const response = await axios.post(`${USER_URL}add`, request)
        return response.data

    } catch (error) {

        console.error(error)

        return parseError(error)
    }
}

function parseError(error: unknown): UserResponse {

    if (axios.isAxiosError(error)) {

        console.log("status = " + error.response?.status)
        console.log("statusText = " + error.response?.statusText)
        console.log("data = " + error.response?.data)

        var errorMsg = error.response?.statusText ?? ""
        if (error.code === 'ERR_NETWORK') {
            errorMsg = 'API 沒開或 Port 錯誤'
        } else  if (error.code === 'ECONNABORTED') {
            errorMsg = 'Request Timeout'
        }

        return {
            code: error.response?.status ?? 0,
            message: errorMsg
        }
    }

    if (error instanceof Error) {
        return {
            code: -999,
            message: error.message
        }
    }

    return {
        code: -9999,
        message: 'Unknown Error'

    }       
}