import React, { useEffect, useState } from 'react';
import axios from 'axios';
import BookItem from './BookItem';

function BookList() 
{
    const [books, setBooks] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');

    useEffect(function() {
        async function fetchBooks() 
        {
            const response = await axios.get('http://localhost:5207/api/books');
            setBooks(response.data);
        }
        fetchBooks();
    }, []);

    const handleSearchChange = function(e) {
        setSearchTerm(e.target.value.toLowerCase());
    };

    const filteredBooks = books.filter(function(book) {
        return (
            book.name.toLowerCase().includes(searchTerm) 
            ||
            book.year.toString().includes(searchTerm) 
            ||
            (book.type && book.type.some(t => t.toLowerCase().includes(searchTerm))) // I don't know why this part doesn't work
        );
    });
    

    return (
        <div className='container'>
            <div className="p-4">
                <h1 className="text-2xl font-bold mb-4">Library Books</h1>
                <input
                    type="text"
                    placeholder="Search by name, year, or type"
                    value={searchTerm}
                    onChange={handleSearchChange}
                    className="border rounded p-2 mb-4 w-full"
                />
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
                    {filteredBooks.length > 0 ? (
                        filteredBooks.map(function(book) {
                            return <BookItem key={book.id} book={book} />;
                        })
                    ) : (
                        <p>No books found.</p>
                    )}
                </div>
            </div>
        </div>
    );
}

export default BookList;
