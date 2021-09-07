interface TUseRequestOptions<TData, TProps> {
    request: (
        props: TProps,
        data: TData
    ) => AxiosRequestConfig | undefined | null
    cancelOnUnmount?: boolean
    onRequest?: (props: TProps) => void
    onSuccess?: (data: TData, props: TProps) => void
    onError?: (error: AxiosError, props: TProps) => void
    onCancel?: (error: AxiosError, props: TProps) => void
}

interface TUseRequestData<TData, TProps> {
    data: TData
    error: AxiosError
    fetching: boolean
    fetched: boolean
    fetch: (props: TProps) => Promise<void>
    cancel: () => void
    canceled: boolean
}

// export const useRequest: <T, P = void>(
//     options: TUseRequestOptions<T, P>,
//     deps?: any[]
// ) => TUseRequestData<T, P>

// export const AxiosContext: React.Context<AxiosContextInterface>
// export const AxiosProvider: React.FC<AxiosContextInterface>

export async function http<T = any>(request: RequestInfo): Promise<T> {
    const response = await fetch(request)
    const body = await response.json()
    return body
}

const f = async () => {
    const response = await fetch(
        'https://jsonplaceholder.typicode.com/todos/',
        {
            method: 'POST',
            headers: {
                'content-type': 'application/json;charset=UTF-8',
            },
            body: JSON.stringify({}),
        }
    )
}
const t = http({
    method: 'GET',
    url: 'https://jsonplaceholder.typicode.com/todos/',
    headers: {
        'content-type': 'application/json;charset=UTF-8',
    },
    body: JSON.stringify({}),
})
