import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import './App.scss';
import Home from './pages/Home/Home';
import Header from './pages/Header/Header';

const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Header></Header>
      <Home></Home>
    </QueryClientProvider>
  )
}

export default App;
