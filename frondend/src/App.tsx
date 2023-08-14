import { useState } from 'react'
import reactLogo from './assets/react.svg'
import './App.css'
import {TranslatorTable} from './components/translatorTable'

function App () {
  const [count, setCount] = useState(0)

  return (
    <div className="App">
      <TranslatorTable></TranslatorTable>
    </div>
  )
}

export default App
