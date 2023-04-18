import { useEffect, useState } from "react"
const API_KEY = 'http://localhost:5226/api/Usuarios';

const App = () =>  {
  const [data,setData] = useState([]);

  useEffect(() => {
    fetch(API_KEY)
    .then(response => response.json())
    .then(data => console.log(data))
  },[])
  return (
    <div className="App">
     
    </div>
  )
}

export default App
