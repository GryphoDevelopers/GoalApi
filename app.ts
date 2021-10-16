import express from 'express';
import * as dotenv from 'dotenv'
import { router } from './src/router/router';
dotenv.config()
const app = express();
const port = process.env.APP_PORT;
app.use('/api', router)
app.listen(port, () => {
    console.log(`The application is listening on port ${port}!`);
})