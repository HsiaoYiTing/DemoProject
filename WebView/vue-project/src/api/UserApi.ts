import axios from 'axios'
import type { UserResponse } from '@/models/UserResponse'

let url = 'http://localhost:5231/api/users/';

export async function getUserById(id: string): Promise<UserResponse> {

  const response = await axios.get(`${url}${id}`)

  return response.data
}

export async function getAllUsers(): Promise<UserResponse> {

  const response = await axios.get(`${url}all`)

  return response.data
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

    const response = await axios.post(`${url}add`, request)

    return response.data
}