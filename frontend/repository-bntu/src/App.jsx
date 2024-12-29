import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext';
import Header from './components/Header';
import AuthorList from './components/AuthorList';
import CategoryList from './components/CategoryList';
import PublicationList from './components/PublicationList';
import UserList from './components/UserList';
import Login from './components/Login';
import Register from './components/Register';
import PublicationForm from "./components/PublicationForm.jsx";
import CategoryForm from "./components/CategoryForm.jsx";
import CategoryPublications from "./components/CategoryPublications.jsx";
import AuthorForm from './components/AuthorForm';
import AuthorPublications from './components/AuthorPublications';
import PublicationDetail from './components/PublicationDetail';
import Favourites from "./components/Favourites.jsx";
import PublicationSearch from "./components/PublicationSearch.jsx";
import {useState} from "react";

const App = () => {
    const [currentPage, setCurrentPage] = useState(1);

    return (
        <AuthProvider>
            <Router>
                <Header />
                <Routes>
                    <Route path="/" element={<PublicationList currentPage={currentPage} setCurrentPage={setCurrentPage} />} />
                    <Route path="/authors" element={<AuthorList />} />
                    <Route path="/categories" element={<CategoryList />} />
                    <Route path="/publications" element={<PublicationList currentPage={currentPage} setCurrentPage={setCurrentPage} />} />
                    <Route path="/users" element={<UserList />} />
                    <Route path="/users/:userId/publications" element={<Favourites />} />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="/publications/new" element={<PublicationForm />} />
                    <Route path="/publications/edit/:id" element={<PublicationForm />} />
                    <Route path="/publications/delete/:id" element={<PublicationForm />} />
                    <Route path="/publications/:publicationId" element={<PublicationDetail />} />
                    <Route path="/categories/new" element={<CategoryForm />} />
                    <Route path="/categories/:categoryId/publications" element={<CategoryPublications />} />
                    <Route path="/authors/new" element={<AuthorForm />} />
                    <Route path="/authors/:authorId/publications" element={<AuthorPublications />} />
                    <Route path="/search" element={<PublicationSearch />} />
                </Routes>
            </Router>
        </AuthProvider>
    );
};

export default App;
