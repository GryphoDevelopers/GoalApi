import express from 'express'
export const router = express.Router();

router.get('/teste', (req, res) => {
    res.send('wiki')
})


