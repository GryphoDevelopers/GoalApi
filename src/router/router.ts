import { authRouter } from './routes'
import express from 'express'
export const router = express()
router.use('/auth', authRouter)
