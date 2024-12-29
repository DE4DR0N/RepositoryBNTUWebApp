import { Link, useNavigate } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Header = () => {
    const { isAuthenticated, userRole, logout } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        document.cookie = 'accessToken=; Max-Age=-99999999;';
        logout();
        navigate('/login');
    };

    return (
        <header className="bg-primary text-gray-800 shadow">
            <div className="container mx-auto flex justify-between items-center py-4">
                <div className="flex items-center">
                    <img src="/BNTU-Logo.jpg" alt="Logo" className="h-10 mr-4" />
                    <h1 className="text-2xl font-bold">BNTU Repository</h1>
                </div>
                <nav className="flex space-x-6">
                    <Link to="/search" className="hover:text-blue-500">Search</Link>
                    <Link to="/" className="hover:text-blue-500">Publications</Link>
                    <Link to="/authors" className="hover:text-blue-500">Authors</Link>
                    <Link to="/categories" className="hover:text-blue-500">Categories</Link>
                    {isAuthenticated ? (
                        <>
                            {userRole === 'Admin' && (
                                <>
                                    <Link to="/users" className="hover:text-blue-500">Users</Link>
                                    <Link to="/publications/new" className="hover:text-blue-500">Add Publication</Link>
                                </>
                            )}
                            <Link to="/favorites" className="hover:text-blue-500">Favorites</Link>
                            <button onClick={handleLogout} className="hover:text-blue-500">Logout</button>
                        </>
                    ) : (
                        <>
                            <Link to="/login" className="hover:text-blue-500">Login</Link>
                            <Link to="/register" className="hover:text-blue-500">Register</Link>
                        </>
                    )}
                </nav>
            </div>
        </header>
    );
};

export default Header;
