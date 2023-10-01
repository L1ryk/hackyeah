export interface ApiInterface<T = Object> {
  result: T
  isSuccess: boolean
  error: string
}

export interface ResultMany<T> {
  itemsCount: number
  items: T[]
}
