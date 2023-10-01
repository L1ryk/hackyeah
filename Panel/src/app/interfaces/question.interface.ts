import { SearchItemInterface } from "./search-item.interface"

export interface QuestionInterface {
  text: string
  filter?: string
  previousHasToBeTruthy?: boolean
  isYesNoQuestion?: boolean
  autocompleteEndpoint?: string
  multiple?: boolean
  staticValues?: SearchItemInterface[]
  hasNullOption?: boolean
}
