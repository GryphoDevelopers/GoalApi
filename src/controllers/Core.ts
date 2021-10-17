import express from "express";
class validationProblemDetails {
    private _type!: string
    private _title!: string | undefined
    private _detail!: string | undefined
    private _instance!: string
    private _status!: number
    private _errors!: Record<string, string[]>
    constructor(
        type: string,
        title: string | undefined,
        detail: string | undefined,
        instance: string,
        status: number,
        errors: Record<string, string[]>
    ) {
        this._type = type;
        this._title = title;
        this._detail = detail;
        this._instance = instance;
        this._status = status;
        this._errors = errors;
        return this
    }
}
export abstract class Core {
    private _errors!: string[];
    public getErrors(): string[] {
        return this._errors;
    }
    public addError(value: string) {
        this._errors.push(value)
    }
    public addErrors(values: string[]) {
        values.map((val) => {
            this.addError(val)
        })
    }
    public async ApiResponse<T = any | undefined>(
        res: express.Response,
        req: express.Request,
        code: number,
        define?: { title?: string, detail?: string },
        obj?: T) {
        if (!(this.getErrors() === undefined || this.getErrors().length === 0)) {
            if (!!obj) {
                res.type('application/json').json(obj)
                return this.ok(res, obj)
            };

            return;
        }
        return res.status(code).json(new validationProblemDetails(
            req.originalUrl, define?.title,
            define?.detail, req.path, code,
            { "errors": this.getErrors() }
        ))
    }
    public ok<T = any | undefined>(
        res: express.Response,
        obj? : T) {
        return res.sendStatus(201).json(obj)
    }
    public created(
        res: express.Response) {
        return res.sendStatus(201)
    }
}