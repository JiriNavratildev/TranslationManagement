import React, { useState, useEffect } from 'react'
import axios from 'axios';

export function TranslatorTable() {

  const [items, setItems] = useState<TranlsationJob[]>([])
  useEffect(() => {
    axios.get('http://localhost:5252/api/translation-jobs').then(res => {
      setItems(res.data)
    });
  }, [])

  const generateRows = (items: TranlsationJob[]) => {
    return (
      <>
        {items.map((item, index) => (
          <tr key={index}>
            <td className="px-6 py-3">{item.id}</td>
            <td className="px-6 py-3">{item.customerName}</td>
            <td className="px-6 py-3">{parseStatus(item.status)}</td>
            <td className="px-6 py-3">{item.price} Kc</td>
          </tr>
        ))}
      </>
    );
  }

  const parseStatus = (status: number) => {
    switch (status) {
      case 0:
        return "NEW"
      case 1:
        return "IN_PROGRESS"
      case 2:
        return "COMPLETED"
    }
  }

  return (
    <div className='relative overflow-x-auto'>
      <h3>Translation jobs</h3>
      <table className='w-full text-sm text-left'>
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th className="px-6 py-3">Id</th>
            <th className="px-6 py-3">Customer Name</th>
            <th className="px-6 py-3">Status</th>
            <th className="px-6 py-3">Price</th>
          </tr>
        </thead>
        <tbody>
          {generateRows(items)}
        </tbody>
      </table>
    </div>
  )
}

interface TranlsationJob {
  id: number
  customerName: string,
  status: number,
  price: number
}

