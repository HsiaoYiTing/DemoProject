import type { User } from "./User"

export interface UserResponse {

  code: number
  message: string
  data: [User]
} 