import { useMainValidator } from "../../models/utils/main-validator";
type tryParseInterface = {
    obj: any | undefined,
    isValid: () => boolean,
    getErrors: () => string[]
}
export function tryParse<T = any | undefined>(json: string): tryParseInterface {
    const { isValid, getErrors, addError } = useMainValidator()
    let obj: T | undefined;
    try {
        obj = JSON.parse(json)
        if(obj) throw new Error('model is invalid!')
        return {
            obj,
            isValid,
            getErrors
        }
    } catch (e: any) {
        addError(e)
        return {
            obj,
            isValid,
            getErrors
        }
    }
}