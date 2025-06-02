export interface LoginRequest {
  userName: string;
  password: string;
}

export interface LoginResponse {
  jwt: string;
  userName: string;
  role: string;
  roleDescripcion: string;
  menu: any[];
}