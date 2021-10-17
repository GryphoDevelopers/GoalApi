import { useMainValidator } from "../../models/utils/main-validator";
export function tryParse<T = any | undefined>(obj : (o : any) => o is T, res: string) {
    const { addError, getErrors, isValid } = useMainValidator()
    try {
        const parsed = JSON.parse(res)
        if(obj(parsed)){
            return {
                getErrors,
                isValid,
                obj,
            }
        }else{
            return {
                getErrors,
                isValid,
                obj,
            }
        }
    }
    catch (e: any) {
        addError(e)
          return {
                getErrors,
                isValid,
                obj,
            }
    }
}
