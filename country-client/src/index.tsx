import React from 'react'
import ReactDOM from 'react-dom'
import './index.scss'
import 'semantic-ui-css/semantic.min.css'
import App from './App'
import { AxiosProvider } from 'react-axios-helpers'
import axios from 'axios'

const customAxiosInstance = axios.create()

ReactDOM.render(
    <React.StrictMode>
        <AxiosProvider instance={customAxiosInstance}>
            <App />
        </AxiosProvider>
    </React.StrictMode>,
    document.getElementById('root')
)
