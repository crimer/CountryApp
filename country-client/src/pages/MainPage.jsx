import React, { useEffect } from 'react'
import {
    Container,
    Divider,
    Dropdown,
    Grid,
    Header,
    Image,
    List,
    Menu,
    Segment,
} from 'semantic-ui-react'
import logo from '../assets/svg/logo.svg'
import { useRequest } from 'react-axios-helpers'

export const MainPage = () => {
    const {
        data,
        error,
        fetching,
        fetched,
        fetch,
        cancel,
        canceled,
    } = useRequest({
        request: () => ({
            method: 'get',
            url: `https://jsonplaceholder.typicode.com/posts`,
        }),
        onRequest: (params) => console.log('onRequest', params),
        onSuccess: (data, params) => console.log('onSuccess', data, params),
        onError: (error, params) => console.log('onError', error, params),
        onCancel: (error, params) => console.log('onCancel', error, params),
    })

    useEffect(() => {
        setTimeout(() => {
            fetch()
        }, 4000)
    }, [])

    return (
        <div
            style={{
                display: 'flex',
                flexFlow: 'column nowrap',
                height: '100vh',
            }}>
            <Menu
                inverted
                style={{
                    borderRadius: 0,
                }}>
                <Container>
                    <Menu.Item as='a' header>
                        <Image
                            size='mini'
                            src={logo}
                            style={{ marginRight: '1.5em' }}
                        />
                        Project Name
                    </Menu.Item>
                    <Menu.Item as='a'>Home</Menu.Item>
                </Container>
            </Menu>

            <Container text style={{ marginTop: '20px', flexGrow: '1' }}>
                <Header as='h1'>Json Placeholder Data Fetched</Header>

                {error && <p>Error!!!</p>}

                {canceled && <p>Canceled!!!</p>}

                {!data && <p>Empty</p>}

                {data &&
                    data.map((el) => (
                        <div key={el.id}>
                            <h3>{el.title}</h3>
                            <p>{el.body}</p>
                        </div>
                    ))}
            </Container>

            <Segment
                inverted
                vertical
                style={{ margin: '5em 0em 0em', padding: '5em 0em' }}>
                <Container textAlign='center'>
                    <Grid divided inverted stackable>
                        <Grid.Column width={3}>
                            <Header inverted as='h4' content='Group 1' />
                            <List link inverted>
                                <List.Item as='a'>Link One</List.Item>
                                <List.Item as='a'>Link Two</List.Item>
                                <List.Item as='a'>Link Three</List.Item>
                                <List.Item as='a'>Link Four</List.Item>
                            </List>
                        </Grid.Column>
                        <Grid.Column width={3}>
                            <Header inverted as='h4' content='Group 2' />
                            <List link inverted>
                                <List.Item as='a'>Link One</List.Item>
                                <List.Item as='a'>Link Two</List.Item>
                                <List.Item as='a'>Link Three</List.Item>
                                <List.Item as='a'>Link Four</List.Item>
                            </List>
                        </Grid.Column>
                        <Grid.Column width={3}>
                            <Header inverted as='h4' content='Group 3' />
                            <List link inverted>
                                <List.Item as='a'>Link One</List.Item>
                                <List.Item as='a'>Link Two</List.Item>
                                <List.Item as='a'>Link Three</List.Item>
                                <List.Item as='a'>Link Four</List.Item>
                            </List>
                        </Grid.Column>
                        <Grid.Column width={7}>
                            <Header inverted as='h4' content='Footer Header' />
                            <p>
                                Extra space for a call to action inside the
                                footer that could help re-engage users.
                            </p>
                        </Grid.Column>
                    </Grid>

                    <Divider inverted section />
                    <Image centered size='small' src={logo} />
                    <List horizontal inverted divided link size='small'>
                        <List.Item as='a' href='#'>
                            Site Map
                        </List.Item>
                        <List.Item as='a' href='#'>
                            Contact Us
                        </List.Item>
                        <List.Item as='a' href='#'>
                            Terms and Conditions
                        </List.Item>
                        <List.Item as='a' href='#'>
                            Privacy Policy
                        </List.Item>
                    </List>
                </Container>
            </Segment>
        </div>
    )
}
