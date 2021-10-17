export function useMainValidator() {
    let _errors!: string[]
    const getErrors = (): string[] => {
        return _errors;
    }
    const addError = (value: string) => {
        _errors.push(value)
    }
    const addErrors = (values: string[]) => {
        values.map((item) => {
            addError(item)
        })
    }
    const isValid = (): boolean => {
        if (_errors !== undefined && _errors.length > 0)
            return false
        return true
    }
    return {
        isValid,
        addError,
        getErrors,
        addErrors
    }
}