export interface QuestionInterface {
  text: string
  filter?: string
  previousHasToBeTruthy?: boolean
  isYesNoQuestion?: boolean
  autocompleteEndpoint?: string
  multiple?: boolean
  staticValues?: string[]
  hasNullOption?: boolean
}
