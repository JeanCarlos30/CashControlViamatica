export interface SystemUser {
  userId?: number;
  userName: string;
  email: string;
  password: string;
  rolId?: number;
  creationDate?: Date;
  userCreate?: number;
  userApproval?: number;
  dateApproval?: Date;
  userStatus_StatusId?: string;
}