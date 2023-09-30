export interface ApiInterface<T = Object> {
  result: T
  isSuccess: boolean
  error: string
}
